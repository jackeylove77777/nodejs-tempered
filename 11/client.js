const dgram = require('dgram')
const fs = require('fs')

const instream = fs.createReadStream('./server.js')

instream.on("readable", () => {
  console.log('in readable');
  send()
})


function send() {
  const message = instream.read(16)
  const socket = dgram.createSocket('udp4')
  if (!message) {
    return socket.unref()//关闭udp连接
  }
  socket.send(message, 0, message.length, 8000, "127.0.0.1", (err, bytes) => {
    send()
  })
}