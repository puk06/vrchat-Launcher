const fs = require("fs");
const path = require("path");

const VRCHATLAUNCHER_FILES = [
    "vrchat-launcher.exe",
    "vrchat-launcher.exe.config"
];

const BUILD_FOLDER = "../build";
const DATA_FOLDER = "../data";

(async () => {
    if (!fs.existsSync(BUILD_FOLDER)) {
        fs.mkdirSync(BUILD_FOLDER);
    } else {
        const BUILD_FOLDER_CONTENTS = fs.readdirSync(BUILD_FOLDER);
        for (const file of BUILD_FOLDER_CONTENTS) {
            const filePath = path.join(BUILD_FOLDER, file);
            console.log(`Deleting ${filePath}`);
            const buildFileStat = fs.statSync(filePath);
            if (buildFileStat.isDirectory()) {
                fs.rmSync(filePath, { recursive: true, force: true });
            } else {
                fs.unlinkSync(filePath);
            }
        }
    }
    
    const DATA_FOLDER_CONTENTS = fs.readdirSync(DATA_FOLDER);
    for (const file of DATA_FOLDER_CONTENTS) {
        const filePath = path.join(DATA_FOLDER, file);
        const stat = fs.statSync(filePath);
        if (stat.isDirectory()) {
            const destPath = path.join(BUILD_FOLDER, file);
            console.log(`Copying ${filePath} to ${destPath}`);
            await copyFolder(filePath, destPath);
        } else {
            const destPath = path.join(BUILD_FOLDER, file);
            console.log(`Copying ${filePath} to ${destPath}`);
            fs.copyFileSync(filePath, destPath);
        }
    }
    
    for (const file of VRCHATLAUNCHER_FILES) {
        const filePath = path.join(BUILD_FOLDER, file);
        console.log(`Copying ${file} to ${filePath}`);
        fs.copyFileSync(file, filePath);
        console.log(`Deleting ${file}`);
        fs.unlinkSync(file);
    }
    
    const fileList = fs.readdirSync(".");
    for (const file of fileList) {
        const filePath = path.join(".", file);
        const stat = fs.statSync(filePath);
        if (file == "build.js") {
            fs.unlinkSync(filePath);
            continue;
        }
        if (file !== "src" && file !== "Updater" && stat.isDirectory()) {
            const destPath = path.join(BUILD_FOLDER, "src", "libs", file);
            console.log(`Copying ${filePath} to ${destPath}`);
            await copyFolder(filePath, destPath);
            console.log(`Deleting ${filePath}`);
            fs.rmSync(filePath, { recursive: true, force: true });
        } else if (file !== "src" && file !== "Updater") {
            const destPath = path.join(BUILD_FOLDER, "src", "libs", file);
            console.log(`Copying ${filePath} to ${destPath}`);
            fs.copyFileSync(filePath, destPath);
            console.log(`Deleting ${filePath}`);
            fs.unlinkSync(filePath);
        }
    }
})()



async function copyFolder(src, dest) {
    await fs.promises.mkdir(dest, { recursive: true });
    const entries = await fs.promises.readdir(src, { withFileTypes: true });

    for (let entry of entries) {
        const srcPath = path.join(src, entry.name);
        const destPath = path.join(dest, entry.name);

        if (entry.isDirectory()) {
            await copyFolder(srcPath, destPath);
        } else {
            await fs.promises.copyFile(srcPath, destPath);
        }
    }
}

console.log("Build completed.");
