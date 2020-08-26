<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
    <div class="container">
      <a class="navbar-brand" href="#">Code Challenge</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExample07" aria-controls="navbarsExample07" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarsExample07">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item" :class="{'active': subIsActive('/characters')}">
            <nuxt-link to="/characters" class="nav-link">GOT Characters</nuxt-link>
          </li>
          <li class="nav-item" :class="{'active': subIsActive('/books')}">
            <nuxt-link to="/books" class="nav-link" href="#">GOT Books</nuxt-link>
          </li>
          <li class="nav-item" :class="{'active': subIsActive('/houses')}">
            <nuxt-link to="/houses" class="nav-link" href="#">GOT Houses</nuxt-link>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script>
    export default {
        name: "NavMenu",
        methods: {
            subIsActive(input) {
                const paths = Array.isArray(input) ? input : [input];

                return paths.some(path => {
                    return this.$route.path.indexOf(path) === 0 // current path starts with this path string
                })
            }
        }
    }
</script>
