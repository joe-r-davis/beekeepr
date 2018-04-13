<template>
  <div class="vaults-cards-wrapper d-flex justify-content-center">
    <div class="card vault-card" style="width: 18rem;">
      <div class="card-body">
        <h5 class="card-title">{{vault.name}} VaultId: {{vault.id}}</h5>
      </div>
      <div class="card-body">
        <ul class="list-group list-group-flush">
          <li class="list-group-item vault-details">{{vault.description}}</li>
          <li class="list-group-item vault-details">
              <div class="container-fluid">
                  <div class="row">
                    <div class="card-deck all-keeps-wrapper d-flex justify-content-center">
                      <myKeeps :keep='myKeep' v-for='myKeep in myKeeps' :key='myKeep.id'></myKeeps>
                    </div>
                  </div>
                </div>
            <Button class="btn btn-danger">
              <a @click='removeVault' class="view-icon">
                <i class="far fa-trash-alt view-icon"></i>
              </a>
            </Button>
          </li>
        </ul>
        <div class="row">
        </div>
        <div class="col">
          <!-- <div v-if="vaultToVault" @mouseleave="vaultToVault = false" class="text-center vaultButton mt-3">
                  <select v-model="selectedVault" @click="addToVault" class="form-control form-control-sm">
                    <option disabled value="">select vault</option>
                    <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
                  </select>
                </div> -->
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import Keeps from './Keeps'
  import MyKeeps from './MyKeeps'
  export default {
    name: 'Vaults',
    data() {
      return {
        selectedVault: "",
        keep: {},
        myKeep: {},
      }
    },
    components: {
      keeps: Keeps,
      myKeeps: MyKeeps,
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      keeps() {
        return this.$store.state.allPublicKeeps;
        console.log(this.$store.state.allPublicKeeps)
      },
      myKeeps() {
        return this.$store.state.allMyKeeps;
        console.log(this.$store.state.allMyKeeps)
      },
      vaults() {
        return this.$store.state.myVaults
      },
    },
    props: ['vault'],
    methods: {
      removeVault() {
        this.$store.dispatch('deleteVault', this.vault)
      },
      addToVault() {
        console.log('Adding to vault', this.selectedVault)

        if (this.selectedVault === "") {
          return
        } else {
          console.log('this is the user', this.user.id)
          // var userId = this.user.id
          console.log('this is the vault', this.vault.id)
          // var vaultId = (this.vault.id)
          console.log('selecting a vault', this.selectedVault)
          // var vaultId = (this.selectedVault)
          var payload = {
            userId: this.user.id,
            vaultId: this.vault.id,
            vaultId: this.selectedVault,
          }
          console.log('adding to vault', payload)
          this.$store.dispatch('addToVault', payload)
        }
        this.selectedVault = ""
      }
    }
  }
</script>

<style>
  /* div {
          outline-color: blue;
          outline-style: solid;
          outline-width: 1px;
        } */

  .vaults-cards-wrapper {
    margin-bottom: 1.5rem;
  }

  .vault-card {
    background-color: rgba(201, 218, 208, 1.0);
  }

  .vault-details {
    background-color: rgba(252, 252, 252, 0.7);

  }

  .vault-button {
    background-color: rgba(0, 102, 78, 1.0);
    border-color: rgba(0, 88, 66, 1.0);
    transition: all;
    transition-duration: 400ms;
    color: rgba(251, 251, 251, 1.0);
  }

  .vault-button:hover {
    background-color: rgba(0, 88, 66, 1.0);
    border-color: rgba(0, 88, 66, 1.0);
  }

  .vault-button:hover,
  .vault-button:visited,
  .vault-button.focus,
  .vault-button:active,
  .vault-button.active:hover {
    background-color: rgba(0, 88, 66, 1.0);
    border-color: rgba(0, 77, 57, 1.0);
  }

  .vaultButtons {
    background: rgba(0, 0, 0, .6);
  }

  a.view-icon:link {
    color: #FFF;
    text-decoration: none;
    font-weight: normal;
  }

  a.view-icon:visited {
    color: #FFF;
    text-decoration: none;
    font-weight: normal;
  }

  a.view-icon:hover {
    color: #FFF;
    text-decoration: underline;
    font-weight: normal;
  }

  a.view-icon:active {
    color: #FFF;
    text-decoration: none;
    font-weight: normal;
  }

  a.share-icon:link {
    color: rgba(0, 0, 0, .6);
    ;
    text-decoration: none;
    font-weight: normal;
  }

  a.share-icon:visited {
    color: rgba(0, 0, 0, .6);
    ;
    text-decoration: none;
    font-weight: normal;
  }

  a.share-icon:hover {
    color: rgba(0, 0, 0, .8);
    ;
    text-decoration: underline;
    font-weight: normal;
  }

  a.share-icon:active {
    color: rgba(0, 0, 0, .6);
    ;
    text-decoration: none;
    font-weight: normal;
  }

  
</style>