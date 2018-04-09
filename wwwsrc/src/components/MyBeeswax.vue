<template>
 
        <div class="my-beeswax">
            <navbar></navbar>
            <div class="container-fluid">
                <h1>{{ user.username }} TEST</h1>
            </div>
        </div>
        


</template>

<script>
  import navbar from './Navbar'
  export default {
    name: "MyBeeswax",
    data() {
      return {};
    },
    components: {
      navbar,
    },
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {

    }
  };
</script>

<style scoped>
  div {
    outline-color: turquoise;
    outline-style: solid;
    outline-width: 1px;
  }
</style>