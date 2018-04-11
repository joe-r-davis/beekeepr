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
            <div class="card-header add-wrapper-top">
              <div class="row mx-1">
                <div class="beeswax-header">
                  My Beeswax
                </div>
                <ul class="nav nav-pills card-header-pills nav-buttons-wrapper my-lg-0 ml-auto" id="myTab" role="tablist">
                  <li class="nav-item">
                    <button type="button" class="btn keep-button" id="keep-tab" data-toggle="tab" href="#keep" role="tab" aria-controls="keep"
                      aria-selected="true">K</button>
                  </li>
                  <li class="nav-item">
                    <button type="button" class="btn vault-button" id="vault-tab" data-toggle="tab" href="#vault" role="tab" aria-controls="vault"
                      aria-selected="false">V</button>
                  </li>
                </ul>
              </div>
            </div>
            <div class="card-body keepr-add-wrapper d-flex justify-content-center">
              <div class="tab-content" id="myTabContent">
                <div class="tab-pane fade show active" id="keep" role="tabpanel" aria-labelledby="keep-tab">
                  <form class="keepr-add-form">
                    <div class="form-group">
                      <input class="form-control" v-model="keep.title" type="text" placeholder="Title" maxlength="20">
                    </div>
                    <div class="form-group">
                      <input class="form-control" v-model="keep.imageUrl" type="text" placeholder="Img Url">
                    </div>
                    <div class="form-group">
                      <input class="form-control" v-model="keep.articleUrl" type="text" placeholder="Link to Article">
                    </div>
                    <div class="form-check">
                      <input type="checkbox" v-model="keep.public" class="form-check-input" id="exampleCheck1">
                      <label class="form-check-label" for="exampleCheck1">Mark as Private?</label>
                    </div>
                    <button type="submit" class="btn btn-success keepr-add-button"  @click.prevent="addKeep">Keep</button>
                    <button class="btn btn-warning mleft" type="reset">Reset</button>
                    <p>This is a place where you can manage your individual keeps</p>
                  </form>








                </div>



                <div class="tab-pane fade" id="vault" role="tabpanel" aria-labelledby="vault-tab">
                  <form class="keepr-add-form">
                    <div class="form-group">
                      <input class="form-control" type="text" placeholder="Title">
                    </div>
                    <div class="form-group">
                      <input class="form-control" type="text" placeholder="Description">
                    </div>
                    <button type="submit" class="btn btn-success vault-button">Add Vault</button>
                    <button class="btn btn-warning mleft" type="reset">Reset</button>
                    <p>Here you can manage your vaults and browse their contents</p>
                  </form>
                </div>
              </div>
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
      return {
        keep: {},
      }
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
      addKeep() {
        this.newKeep = {
        title: this.keep.title,
        imageUrl: this.keep.imageUrl,
        articleUrl: this.keep.articleUrl,
        userId: this.$store.state.user.id
        }
        this.$store.dispatch('createKeep', this.newKeep)
      }
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

  .keep-image {
    width: 300px;
  }

  .keep-card {
    width: 300px;
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

  .add-wrapper-top {
    background-color: rgba(232, 228, 197, 1.0)
  }

  .keepr-add-form {
    width: 100%;
  }

  .tab-content {
    width: 80%;
  }

  .keepr-add-wrapper {
    background-color: rgba(232, 228, 197, .5)
  }

  .keepr-add-button {
    background-color: rgba(0, 102, 78, 1.0);
    border-color: rgba(0, 88, 66, 1.0);
    transition: all;
    transition-duration: 400ms;
    color: rgba(251, 251, 251, 1.0);
    margin: .5rem;
  }

  .keepr-add-button:hover {
    background-color: rgba(0, 88, 66, 1.0);
    border-color: rgba(0, 88, 66, 1.0);
  }

  .keepr-add-button:hover,
  .keepr-add-button:visited,
  .keepr-add-button.focus,
  .keepr-add-button:active,
  .keepr-add-button.active:hover {
    background-color: rgba(0, 88, 66, 1.0);
    border-color: rgba(0, 77, 57, 1.0);
  }
</style>