const zlib = require('zlib')
const rawStr = "For fear of losing you,I would never cry.";
//压缩
zlib.deflate(rawStr, (err, buf) => {
  if (!err) {
    console.log(buf.toString())

    //解压缩
    zlib.inflate(buf, (err, primaryBuf) => {
      if (!err) {
        console.log(primaryBuf.toString());
      }
    })
  }
})

var gzip = zlib.createGzip();
var fs = require("fs");
var inp = fs.createReadStream("input.txt");
var out = fs.createWriteStream("input.txt.gz");

inp.pipe(gzip).pipe(out);
