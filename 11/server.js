const dgram = require('dgram')

const socket = dgram.createSocket("udp4")

socket.on("message", (msg, info) => {
  process.stdout.write(msg.toString())
})

socket.on("listening", () => {
  console.log("server ready: ",socket.address());
})
socket.bind(8000)