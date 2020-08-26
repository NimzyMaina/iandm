<template>
  <div>
    <nav-menu></nav-menu>
    <div class="container">
      <div class="row mt-5">
        <h3>Game of Thrones Books</h3>
        <div class="table-responsive">
          <table class="table table-bordered table-striped">
            <thead>
            <tr>
              <th>Name</th>
              <th>ISBN</th>
              <th>Authors</th>
              <th>Pages</th>
              <th>Publisher</th>
              <th>Country</th>
              <th>Media Type</th>
              <th>Characters</th>
              <th>Release Date</th>
            </tr>
            </thead>
            <tbody>
            <tr v-for="x in book_list">
              <td>{{x.name}}</td>
              <td>{{x.isbn}}</td>
              <td>{{show_many(x.authors)}}</td>
              <td>{{x.numberOfPages}}</td>
              <td>{{x.publisher}}</td>
              <td>{{x.country}}</td>
              <td>{{x.mediaType}}</td>
              <td>{{x.characters.length}}</td>
              <td>{{x.released}}</td>
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
        name: "books",
        components: { NavMenu },
        async mounted() {
            await this.$store.dispatch('fetchBooks');
        },
        computed: {
            isLoading(){
                return this.$store.getters.is_loading;
            },
            book_list() {
                return this.$store.getters.books;
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
