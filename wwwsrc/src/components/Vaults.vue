<template>
        <div class="vaults-cards-wrapper d-flex justify-content-center">
          <div class="card vault-card" @mouseenter="vaultButtons = true" @mouseleave="vaultButtons = false" style="width: 18rem;">
            <img class="card-img-top" :src="imgLink" alt="Card image cap">
            <div class="card-body">
              <ul class="list-group list-group-flush">
                <li class="list-group-item text-center vault-details">
                  <span>K: {{vault.vaultCount}}</span>
                  <span>
                    <i class="fas fa-share"></i>: {{vault.shareCount}}</span>
                  <span>
                    <i class="fas fa-eye"></i>: {{vault.viewCount}}</span>
                </li>
                <li class="list-group-item vault-details">{{vault.title}}</li>
                <li class="list-group-item vault-details">
                  <div v-if="vaultButtons = vaultButtons ? true: false" class="text-center">
                    <Button class="btn vault-button" @click="vaultToVault = vaultToVault ? false : true">K</Button>
                    <Button class="btn btn-dark" @click="shareBox = shareBox ? false : true">
                      <i class="fas fa-share"></i>
                    </Button>
                    <Button class="btn btn-secondary">
                      <a :href="vault.imageUrl" @click='updateViewCount' class="view-icon" target="_blank" title="vault.title">
                        <i class="fas fa-eye view-icon"></i>
                      </a>
                    </Button>
                  </div>
                </li>
              </ul>
              <div class="row">
                <div class="col">
                  <div v-if="shareBox" class="shareButton vault-details">
                    <span>
                      <a :href="'https://www.facebook.com/sharer/sharer.php?u=' + vault.articleUrl" @click='updateShareCount' class="share-icon"
                        target="_blank" title="Share on Facebook">
                        <i class="fab fa-facebook"></i>
                      </a>
                    </span>
                    <span>
                      <a :href="'https://twitter.com/intent/tweet?url=' + vault.articleUrl + '&text=TEXT&via=YOURTWITTERACCOUNTNAME'" @click='updateShareCount'
                        class="share-icon" target="_blank" title="Share on Twitter">
                        <i class="fab fa-twitter"></i>
                      </a>
                    </span>
                  </div>
                </div>
              </div>
              <div class="col">
                <div v-if="vaultToVault" @mouseleave="vaultToVault = false" class="text-center vaultButton mt-3">
                  <select v-model="selectedVault" @click="addToVault" class="form-control form-control-sm">
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
          name: 'Vaults',
          data() {
            return {
              shareBox: false,
              vaultButtons: false,
              vaultToVault: false,
              selectedVault: "",
            }
          },
          computed: {
            imgLink() {
              return this.vault.imageUrl
            },
            vaults() {
              return this.$store.state.allUserVaults
            },
          },
          props: ['vault', 'user'],
          methods: {
            removeVault() {
              this.$store.dispatch('deleteVault', this.vault)
            },
            updateShareCount() {
              this.$store.dispatch('updateShareCount', this.vault)
            },
            updateViewCount() {
              this.$store.dispatch('updateViewCount', this.vault)
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
          color: rgba(0, 0, 0, .6);;
          text-decoration: none;
          font-weight: normal;
        }
      
        a.share-icon:visited {
          color: rgba(0, 0, 0, .6);;
          text-decoration: none;
          font-weight: normal;
        }
      
        a.share-icon:hover {
          color: rgba(0, 0, 0, .8);;
          text-decoration: underline;
          font-weight: normal;
        }
      
        a.share-icon:active {
          color: rgba(0, 0, 0, .6);;
          text-decoration: none;
          font-weight: normal;
        }
      </style>