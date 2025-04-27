const fs = require("fs");
const path = require("path");

const VRCHATLAUNCHER_FILES = [
    "vrchat-launcher.exe",
    "vrchat-launcher.exe.config"
];

const BUILD_FOLDER = "../build";
const FONT_FOLDER = "../../Fonts";

const EMPTY_JSON_DATA = {
    "Softwares": [],
    "Profiles": [],
    "LastSelectedDesktopMode": false,
    "LastSelectedProfile": ""
};

(async () => {
    if (!fs.existsSync(BUILD_FOLDER)) {
        fs.mkdirSync(BUILD_FOLDER);
    }

    const srcFolder = path.join(BUILD_FOLDER, "src");
    fs.mkdirSync(srcFolder, { recursive: true });
    fs.mkdirSync(path.join(srcFolder, "Fonts"), { recursive: true });
    fs.mkdirSync(path.join(srcFolder, "libs"), { recursive: true });
    fs.writeFileSync(path.join(srcFolder, "data.json"), JSON.stringify(EMPTY_JSON_DATA, null, 4));

    let files = fs.readdirSync("./");
    files = files.filter(file => file != "build.js");

    for (const file of files) {
        if (VRCHATLAUNCHER_FILES.includes(file)) {
            fs.copyFileSync(file, path.join(BUILD_FOLDER, file));
            continue;
        }

        const fileStats = fs.statSync(file);
        if (fileStats.isDirectory()) {
            const folderPath = path.join(path.join(srcFolder, "libs"), file);
            console.log(`Copying folder ${file} to ${folderPath}`);
            await copyFolder(file, folderPath);
        } else {
            const filePath = path.join(path.join(srcFolder, "libs"), file);
            console.log(`Copying ${file} to ${filePath}`);
            fs.copyFileSync(file, filePath);
        }
    }

    const Fonts = fs.readdirSync(FONT_FOLDER);
    for (const font of Fonts) {
        const fontPath = path.join(FONT_FOLDER, font);
        console.log(`Copying ${font} to ${path.join(srcFolder, "Fonts", font)}`);
        fs.copyFileSync(fontPath, path.join(srcFolder, "Fonts", font));
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
