<template>
  <div class="hello">
    <h1>Hello</h1>
    <button v-on:click="getTheBoards">Click Me</button>
    <div class="board" v-for="(board, index) in boards" :key="index">
      <h2>{{ board.title }}</h2>
    </div>
  </div>
</template>

<script>
import BoardService from "@/services/BoardService";

export default {
  name: "board-list",
  props: {
    msg: String,
  },
  data() {
    return {
      boards: [],
    };
  },
  methods: {
    getTheBoards() {
      BoardService.getBoards().then((result) => (this.boards = result.data));
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped></style>
