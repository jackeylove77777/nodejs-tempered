const net = require("net");

let id = 0
const netServer = net.createServer((socket) => {
  id++
  console.log(`client ${id} connected`);

  socket.on('end', () => {
    console.log(`client ${id} disconnected`)
  })
  socket.on('data', () => {
    socket.write('receive! ')
  })
  socket.write('welcome!')

});

netServer.listen(7777, () => {
  console.log("running");
});
