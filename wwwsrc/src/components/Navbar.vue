<template>
  <div class="navbar-wrapper">
    <nav class="navbar navbar-expand-md navbar-custom">
        <!-- @click="home" -->
      <a class="navbar-brand">
        <img src="../assets/beekeepr-nav-logo.png" class="nav-logo" alt="beekeepr">
      </a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCustom">
        <i class="fa fa-bars fa-lg py-1 text-black"></i>
      </button>
      <div class="navbar-collapse collapse mx-2" id="navbarCustom">
        <ul class="navbar-nav">
          <!-- <li class="nav-item">
            <a class="nav-link" @click="home">Keeps</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" @click="home">Vaults</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" @click="home">My Profile</a>
          </li> -->
        </ul>
        <div class="nav-buttons-wrapper my-2 my-lg-0 ml-auto">
          <button class="btn btn-success signInButton" data-toggle="modal" data-target="#loginModal">Login</button>
          <button class="btn btn-primary registerButton" data-toggle="modal" data-target="#registerModal">Register</button>
          <!-- <button class="btn btn-secondary my-2 my-sm-0" @click="logout">Logout</button> -->
          <div class="modal fade" id="loginModal" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered" role="document">
              <div class="modal-content">
                <div class="modal-header">
                  <h5 class="modal-title" id="modalLabel">Login</h5>
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div class="modal-body">
                  <form @submit.prevent="login">
                    <input type="email" placeholder="email" v-model="loginUser.email">
                    <input type="password" placeholder="password" v-model="loginUser.password">
                    <button type="submit" class="btn btn-success signInButton">Login</button>
                  </form>
                </div>
              </div>
            </div>
          </div>
          <div class="modal fade" id="registerModal" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered" role="document">
              <div class="modal-content">
                <div class="modal-header">
                  <h5 class="modal-title" id="modalLabel">Register</h5>
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div class="modal-body">
                  <form @submit.prevent="register">
                    <input type="text" placeholder="username" v-model="newUser.username">
                    <input type="email" placeholder="email" v-model="newUser.email">
                    <input type="password" placeholder="password" v-model="newUser.password">
                    <button type="submit" class="btn btn-success registerButton">Register</button>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
  export default {
    name: 'Navbar',
    data() {
      return {
        loginUser: {
          email: '',
          password: ''
        },
        newUser: {
          username: '',
          email: '',
          password: ''
        }
      }
    },
    methods: {
      login() {
        this.$store.dispatch('login', this.loginUser)
      },
      register() {
        this.$store.dispatch('register', this.newUser)
      }
    }
  }
</script>

<style scoped>
  div {
    outline-color: red;
    outline-style: solid;
    outline-width: 1px;
  }

  .nav-logo {
    height: 80px;
    cursor: pointer;
  }

  .nav-link {
    cursor: pointer;
  }

  .navbar-custom {
    background-color: rgba(201, 218, 208, 1.0)
  }

  .signInButton {
    background-color: rgba(0, 102, 78, 1.0);
    border-color: rgba(0, 88, 66, 1.0);
    transition: all;
    transition-duration: 400ms;
    color: rgba(251, 251, 251, 1.0);
    margin: .5rem;
  }

  .signInButton:hover {
    background-color: rgba(0, 88, 66, 1.0);
    border-color: rgba(0, 88, 66, 1.0);
  }

  .signInButton:hover,
  .signInButton:visited,
  .signInButton.focus,
  .signInButton:active,
  .signInButton.active:hover {
    background-color: rgba(0, 88, 66, 1.0);
    border-color: rgba(0, 77, 57, 1.0);
  }

    .registerButton {
    background-color: rgba(149, 121, 92, 1.0);
    border-color: rgba(123, 101, 75, 1.0);
    transition: all;
    transition-duration: 400ms;
    color: rgba(251, 251, 251, 1.0);
    margin: .5rem;
  }

  .registerButton:hover {
    background-color: rgba(123, 101, 75, 1.0);
    border-color: rgba(123, 101, 75, 1.0);
  }

  .registerButton:hover,
  .registerButton:visited,
  .registerButton.focus,
  .registerButton:active,
  .registerButton.active:hover {
    background-color: rgba(123, 101, 75, 1.0);
    border-color: rgba(109, 89, 66, 1.0);
  }
</style>