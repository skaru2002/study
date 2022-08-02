import http from 'http';
import express from 'express';
import socketIO from 'socket.io'

const app = express();

app.use("/public", express.static(__dirname + "/public"));
app.get("/", (_,res) => res.sendFile(__dirname + '/main.html'))
app.get("/*", (_,res) => res.redirect("/"));

const httpServer = http.createServer(app);
const wsServer = socketIO(httpServer);

wsServer.on("connection", (socket) => {
  console.log(socket);
})

const port = 8000;
const handleListen = () => {console.log(`Listening on http://localhost:${port}`);}
httpServer.listen(port, handleListen)