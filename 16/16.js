const cp = require("child_process");

cp.exec("echo | netstat -an",function(err,stdout,stderr){
    if(err){
        console.error(err);
    }
    console.log("stdout:",stdout)
    console.log("stderr:",stderr);
});