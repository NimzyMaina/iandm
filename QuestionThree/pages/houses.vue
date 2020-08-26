<template>
  <div>
    <nav-menu></nav-menu>
    <div class="container">
      <div class="row mt-5">
        <h3>Game of Thrones Houses</h3>
        <div class="table-responsive">
          <table class="table table-bordered table-striped">
            <thead>
            <tr>
              <th>Name</th>
              <th>Region</th>
              <th>CoA</th>
              <th>Words</th>
              <th>Founder</th>
              <th>Current Lord</th>
              <th>Heir</th>
            </tr>
            </thead>
            <tbody>
            <tr v-for="x in house_list">
              <td>{{x.name}}</td>
              <td>{{x.region}}</td>
              <td>{{x.coatOfArms}}</td>
              <td>{{show_one(x.words)}}</td>
              <Promised :promise="getCharacter(x.founder)">
                <!-- Use the "pending" slot to display a loading message -->
                <template v-slot:pending>
                  <td>Loading...</td>
                </template>
                <!-- The default scoped slot will be used as the result -->
                <template v-slot="data">
                  <td>{{data}}</td>
                </template>
                <!-- The "rejected" scoped slot will be used if there is an error -->
                <template v-slot:rejected="error">
                  <td>Error: {{ error.message }}</td>
                </template>
              </Promised>
              <Promised :promise="getCharacter(x.currentLord)">
                <!-- Use the "pending" slot to display a loading message -->
                <template v-slot:pending>
                  <td>Loading...</td>
                </template>
                <!-- The default scoped slot will be used as the result -->
                <template v-slot="data">
                  <td>{{data}}</td>
                </template>
                <!-- The "rejected" scoped slot will be used if there is an error -->
                <template v-slot:rejected="error">
                  <td>Error: {{ error.message }}</td>
                </template>
              </Promised>
              <Promised :promise="getCharacter(x.heir)">
                <!-- Use the "pending" slot to display a loading message -->
                <template v-slot:pending>
                  <td>Loading...</td>
                </template>
                <!-- The default scoped slot will be used as the result -->
                <template v-slot="data">
                  <td>{{data}}</td>
                </template>
                <!-- The "rejected" scoped slot will be used if there is an error -->
                <template v-slot:rejected="error">
                  <td>Error: {{ error.message }}</td>
                </template>
              </Promised>
            </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>

    <client-only>
      <loading :active.sync="isLoading"
               :can-cancel="false"
               :is-full-page="fullPage"></loading>
    </client-only>
  </div>

</template>

<script>
    import NavMenu from '~/components/NavMenu.vue'
    export default {
        name: "houses",
        components: { NavMenu },
        async mounted() {
            await this.$store.dispatch('fetchHouses');
        },
        computed: {
            isLoading(){
                return this.$store.getters.is_loading;
            },
            house_list() {
                return this.$store.getters.houses;
            }
        },
        data() {
            return {
                fullPage: true
            }
        }
    }
</script>

<style scoped>

</style>
