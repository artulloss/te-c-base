import axios from "axios";

const http = axios.create({
  baseURL: "https://localhost:5001",
});

export default {
  getBoards() {
    return http.get("/boards");
  },
};
