<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'App',
  // mounted() {
  //   this.$store.dispatch('authenticateUser')
  // }
}
</script>

<style scoped>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;

}
/* div {
  outline-color: springgreen;
  outline-style: solid;
  outline-width: 1px;
} */
</style>
