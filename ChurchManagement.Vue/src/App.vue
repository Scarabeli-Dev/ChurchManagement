<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
import Header from './components/shared/Header.vue'
import Footer from './components/shared/Footer.vue'

</script>

<template>
  <Header />
  <RouterView />
  <Footer />
</template>

<style scoped></style>
