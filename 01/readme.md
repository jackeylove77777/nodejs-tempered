#### commandLine:
```
node main.js > stout.js.log 2> stderr.js.log
dotnet-exec main.cs > stdout.cs.log 2> stderr.cs.log
```
与nodejs相比，C#的Console类的方法更灵活，可以程序内动态设置流的输入与输出

而nodejs没有查询到相应的设置流的方法，只能通过的重定向操作符来改变流的输出


其中input.txt为C#程序内设置的标准输入流来源文件
output.txt为C#程序内设置的标准输出流文件
err.txt程序内设置的标准错误流来源文件