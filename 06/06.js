const EventEmitter = require('events').EventEmitter;
const event = new EventEmitter();

//定义事件监听器
event.on('event1', () => {
  console.log('event1.1 触发')
})
//可以定义多个事件监听器
event.on("event1", (a,b) => {
  console.log("event1.2 触发");
  console.log(a+b);//3
});
//触发事件
setTimeout(() => {
  event.emit('event1',1,2)
},1000)
