const cp = require('child_process')

const netstat = cp.spawn("netstat", ["-an"])
const echo = cp.spawn("cmd", ["echo"])

netstat.stdout.pipe(echo.stdin)
echo.stdout.pipe(process.stdout)