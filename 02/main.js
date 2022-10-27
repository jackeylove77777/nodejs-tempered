console.log(process.arch); //获取系统是32位还是64位
console.log(process.platform); //获取操作系统类型

console.log(process.memoryUsage().rss); //进程常驻内存大小
console.log(process.memoryUsage().heapTotal); //动态分配的堆内存大小
console.log(process.memoryUsage().heapUsed); //已经使用的堆内存大小

console.log(process.argv); //获取命令行参数
