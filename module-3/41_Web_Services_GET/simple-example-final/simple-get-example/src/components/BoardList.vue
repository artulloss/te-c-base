<template>
  <div>
      <h1>Here we are</h1>
      <button v-on:click="getTheBoards">Click Me </button>
      <h2>{{boards.length}}</h2>

        <button v-on:click="getACat">Click Me For a Cat</button>
        <img v-bind:src="catImageUrl"/>
  </div>
</template>

<script>
import boardService from '@/services/BoardService.js';
import catService from '@/services/CatService.js';

export default {
    data() {
        return {
            boards: [],
            catImageUrl: ''
        }
    },
    methods: {
        getTheBoards() {
            boardService.getBoards().then( response => {
                console.log(response);
                this.boards = response.data;
            })
        },
        getACat(){
            catService.getCat().then( response=>{
                this.catImageUrl = response.data[0].url;

            })
        }
    }

}
</script>

<style>

</style>