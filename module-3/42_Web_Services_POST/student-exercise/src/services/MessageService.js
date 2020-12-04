import axios from "axios";

const http = axios.create({
  baseURL: "http://localhost:3000/",
});

export default {
  get: (id) => {
    return http.get(`messages/${id}`);
  },

  createMessage: (message) => {
    return http.post("messages", message);
  },

  updateMessage: (messageId, message) => {
    return http.put(`messages/${messageId}`, message);
  },

  deleteMessage: (messsageId) => {
    return http.delete(`messages/${messsageId}`);
  },
};
