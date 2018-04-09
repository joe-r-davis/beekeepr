<template>

  <div class="my-beeswax">
    <navbar></navbar>
    <div class="container-fluid">
      <div class="row">
        <div class="container">
          <div class="row dashboard-intro">
            Hello {{user.username}}, here you may post your own keeps, manage your vaults, and be awesome.
          </div>
          <div class="row card mt-4">
            <div class="card-header">
              <div class="row">
                <div class="beeswax-header">
                  My Beeswax
                </div>

                  <ul class="nav nav-pills card-header-pills nav-buttons-wrapper my-lg-0 ml-auto">
                    <li class="nav-item">
                      <button type="button" class="btn btn-success keep-button">K</button>
                    </li>
                    <li class="nav-item">
                      <button type="button" class="btn btn-success vault-button">V</button>
                    </li>
                  </ul>

              </div>
            </div>
            <div class="card-body">
              <h5 class="card-title">Special title treatment</h5>
              <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
              <a href="#" class="btn btn-primary">Go somewhere</a>
            </div>
          </div>
        </div>
      </div>
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

  .dashboard-intro {
    background-color: rgba(0, 102, 78, 1.0);
    color: white;
    margin-top: 2rem;
    padding: 1rem;
  }

  .keep-button {
    background-color: rgba(0, 102, 78, 1.0);
    border-color: rgba(0, 88, 66, 1.0);
    transition: all;
    transition-duration: 400ms;
    color: rgba(251, 251, 251, 1.0);
    margin: .5rem;
  }

  .keep-button:hover {
    background-color: rgba(0, 88, 66, 1.0);
    border-color: rgba(0, 88, 66, 1.0);
  }

  .keep-button:hover,
  .keep-button:visited,
  .keep-button.focus,
  .keep-button:active,
  .keep-button.active:hover {
    background-color: rgba(0, 88, 66, 1.0);
    border-color: rgba(0, 77, 57, 1.0);
  }

  .vault-button {
    background-color: rgba(149, 121, 92, 1.0);
    border-color: rgba(123, 101, 75, 1.0);
    transition: all;
    transition-duration: 400ms;
    color: rgba(251, 251, 251, 1.0);
    margin: .5rem;
  }

  .vault-button:hover {
    background-color: rgba(123, 101, 75, 1.0);
    border-color: rgba(123, 101, 75, 1.0);
  }

  .vault-button:hover,
  .vault-button:visited,
  .vault-button.focus,
  .vault-button:active,
  .vault-button.active:hover {
    background-color: rgba(123, 101, 75, 1.0);
    border-color: rgba(109, 89, 66, 1.0);
  }

  .beeswax-header {
    font-size: 1.6rem;
    vertical-align: middle;
    padding-top: .5rem;
  }
</style>