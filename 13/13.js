const cp = require('child_process')

cp.execFile("ping", ["www.baidu.com"], (err, stdout, stderr) => {
  if (err) {
    console.error(err);
  } else {
    console.log("stdout: ",stdout);
    console.log("stderr: ",stderr)
  }
})
//打开了记事本，当记事本被关闭了才会发生回调
cp.execFile('notepad', (err, stdout, stderr) => {
    if (err) {
      console.error(err);
    } else {
      console.log("stdout: ", stdout);
      console.log("stderr: ", stderr);
    }
})