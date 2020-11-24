<template>
  <div>
    <label for="fname">One Way Binding:</label>
    <input type="text" id="fname" name="fname" v-bind:value="oneWay"/><br /><br />
    <p> Another example of one way data binding {{oneWay}}</p>
    <label for="lname">Two Way Binding:</label>
    <input type="text" id="lname" name="lname" v-model="twoWay"/><br /><br />

    <p> here is the computed property {{combo}}</p>
  </div>
</template>

<script>
export default {
    data() {
        return {
            oneWay: 'Katie',
            twoWay: 'Brian'
        }
    },
    computed: {
        combo() {
            return this.oneWay + ' '+this.twoWay;
        }
    }
};
</script>

<style>
</style>