const cp = require('child_process')
//execFile
const stdout1 = cp.execFileSync("ping", ["www.baidu.com"]).toString()
console.log(stdout1);

//spawn
const stdout2 = cp.spawnSync("ping", ["www.baidu.com"]).stdout.toString()
console.log(stdout2);

//execFile
const stdout3 = cp.execSync("dir").toString()
console.log(stdout3);