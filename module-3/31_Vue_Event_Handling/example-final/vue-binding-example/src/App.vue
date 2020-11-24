<template>
  <div id="app">
  
    <data-binding-example />
  </div>
</template>

<script>
import DataBindingExample from './components/DataBindingExample.vue'

export default {
  name: 'App',
  components: {
    DataBindingExample
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
