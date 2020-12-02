<template>
  <div>
    <div class="loading" v-if="isLoading">
      <img src="../assets/ping_pong_loader.gif" />
    </div>
    <div v-else>
      <h1>{{ card.title }}</h1>
      <p>{{ card.description }}</p>
      <comments-list v-bind:comments="card.comments" />
    </div>
  </div>
</template>

<script>
import boardsService from "../services/BoardService.js";
import CommentsList from "@/components/CommentsList.vue";

export default {
  name: "card-detail",
  data() {
    return {
      card: {
        title: "",
        description: "",
        status: "",
        comments: [],
      },
      isLoading: true,
    };
  },
  created() {
    const boardId = this.$route.params.boardID;
    const cardId = this.$route.params.cardID;
    boardsService.getCard(boardId, cardId).then((response) => {
      this.card = response;
      this.isLoading = false;
    });
    //this code might execute before line 35 does
  },
  components: {
    CommentsList,
  },
};
</script>
