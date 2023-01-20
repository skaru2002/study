import http from 'http';
import express from 'express';
import SocketIO from 'socket.io'
// import { Server } from 'socket.io';

const app = express();

app.use("/public", express.static(__dirname + "/public"));

const MSG_TITLE = "Westo Signaling Server";

app.get("/", (_, res) => {
  return res.status(200).json({
    title: MSG_TITLE,
    version: "1.0.0",
  });
});

app.get("/*", (_,res) => res.redirect("/"));

let options = {
  requestCert: false,
  rejectUnauthorized: false
};

const httpServer = http.createServer(options, app);

const wsServer = SocketIO(httpServer, { 
  allowEIO3: true,
  cors: {
    origin: true,
    credentials: true,
  }
});

const port = 8000;
const handleListen = () => {console.log(`Listening on http://localhost:${port}`);}

httpServer.listen(port, handleListen)

wsServer.on("connection", (socket) => {
  console.log(socket);
  console.log("connection");
  socket.on("join_room", (roomName) => {
    console.log("join_room");
    socket.join(roomName);
    socket.to(roomName).emit("joined");
  });
  socket.on("offer", (offer, roomName) => {
    console.log("offer");
    socket.to(roomName).emit("offer", offer);
  });
  socket.on("answer", (answer, roomName) => {
    console.log("answer");
    socket.to(roomName).emit("answer", answer); 
  });
  socket.on("ice", (ice, roomName) => {
    console.log("ice");
    socket.to(roomName).emit("ice", ice);
  });
});

