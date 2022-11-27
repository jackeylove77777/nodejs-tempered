const cp = require("child_process");
const http = require("http");

http
  .createServer((req, res) => {
    child = cp.spawn("ping", ["-t", "www.baidu.com"]);
    child.on("error", console.error);
    child.stdout.pipe(res);
    child.stderr.pipe(res);
  })
  .listen(8000);
