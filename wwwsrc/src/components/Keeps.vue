<template>
  <div class="keeps-cards-wrapper d-flex justify-content-center">
    <div class="card keep-card" @mouseenter="keepButtons = true" @mouseleave="keepButtons = false" style="width: 18rem;">
      <img class="card-img-top" :src="imgLink" alt="Card image cap">
      <div class="card-body">
        <ul class="list-group list-group-flush">
          <li class="list-group-item text-center keep-details">
            <span>K: {{keep.countKeep}} 0 </span>
            <span>
              <i class="fas fa-share"></i>: {{keep.countShare}} 0</span>
            <span>
              <i class="fas fa-eye"></i>: {{keep.countView}} 0 </span>
          </li>
          <li class="list-group-item keep-details">{{keep.title}}</li>
          <li class="list-group-item keep-details">
            <div v-if="keepButtons = keepButtons ? true: false" class="text-center">
              <Button class="btn keep-button" @click="keepToVault = keepToVault ? false : true">K</Button>
              <Button class="btn btn-dark" @click="shareBox = shareBox ? false : true">
                <i class="fas fa-share"></i>
              </Button>
              <Button class="btn btn-secondary">
                <i class="fas fa-eye"></i>
              </Button>
            </div>
          </li>
        </ul>
        <div class="row">
          <div class="col">
            <div v-if="shareBox" class="shareButton keep-details">
              <span>
                <!-- <a :href='facebook' class="share-icon" @click='updateShareCount' target="_blank" title="Share on Facebook"> -->
                <i class="fab fa-facebook"></i>
                <!-- </a> -->
              </span>
              <span>
                <!-- <a class="share-icon" @click='updateShareCount' :href="twitter" target="_blank"> -->
                <i class="fab fa-twitter"></i>
                <!-- </a> -->
              </span>
            </div>
          </div>
        </div>
        <div class="col">
          <div v-if="keepToVault" @mouseleave="keepToVault = false" class="text-center keepButton mt-3">
            <select v-model="selectedVault" @click="addToVault">
              <option disabled value="">select vault</option>
              <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
            </select>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'Keeps',
    data() {
      return {
        shareBox: false,
        keepButtons: false,
        keepToVault: false,
        selectedVault: "",
      }
    },
    computed: {
      imgLink() {
        return this.keep.imageUrl
      },
      vaults() {
        return this.$store.state.allUserVaults
      },
    },
    props: ['keep', 'user'],
    methods: {
      removeKeep() {
        this.$store.dispatch('deleteKeep', this.keep)
      },
      addToVault() {
        console.log('Adding to vault', this.selectedVault)

        if (this.selectedVault === "") {
          return
        } else {
          console.log('this is the user', this.user.id)
          // var userId = this.user.id
          console.log('this is the keep', this.keep.id)
          // var keepId = (this.keep.id)
          console.log('selecting a vault', this.selectedVault)
          // var vaultId = (this.selectedVault)
          var payload = {
            userId: this.user.id,
            keepId: this.keep.id,
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

.keeps-cards-wrapper {
  margin-bottom: 1.5rem;
}

  .keep-card {
    background-color: rgba(201, 218, 208, 1.0)
  }

  .keep-details {
    background-color: rgba(252, 252, 252, 0.7)
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

  .keepButtons {
    background: rgba(0, 0, 0, .6);
  }
</style>