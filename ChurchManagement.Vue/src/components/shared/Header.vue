<template>
  <header id="header" class="header d-flex align-items-center fixed-top" :class="{ 'bg-dark opacity-75': isScrolled }">
    <div class="container position-relative d-flex align-items-center justify-content-between">

      <RouterLink :to="{ name: 'home' }" class="logo d-flex align-items-center me-auto me-xl-0">
        <!-- Uncomment the line below if you also wish to use an image logo -->
        <!-- <img src="assets/img/logo.png" alt=""> -->
        <h1 class="sitename">KnightOne</h1>
      </RouterLink>

      <nav id="navmenu" class="navmenu">
        <ul>
          <li>
            <RouterLink to="#hero" class="active">Home</RouterLink>
          </li>
          <li>
            <RouterLink to="about">About</RouterLink>
          </li>
          <li>
            <RouterLink to="#services">Services</RouterLink>
          </li>
          <li>
            <RouterLink to="#portfolio">Portfolio</RouterLink>
          </li>
          <li>
            <RouterLink to="#pricing">Pricing</RouterLink>
          </li>
          <li>
            <RouterLink to="blog.html">Blog</RouterLink>
          </li>
          <li class="dropdown"><a href="#"><span>Dropdown</span> <i class="bi bi-chevron-down toggle-dropdown"></i></a>
            <ul>
              <li><a href="#">Dropdown 1</a></li>
              <li class="dropdown"><a href="#"><span>Deep Dropdown</span> <i
                    class="bi bi-chevron-down toggle-dropdown"></i></a>
                <ul>
                  <li><a href="#">Deep Dropdown 1</a></li>
                  <li><a href="#">Deep Dropdown 2</a></li>
                  <li><a href="#">Deep Dropdown 3</a></li>
                  <li><a href="#">Deep Dropdown 4</a></li>
                  <li><a href="#">Deep Dropdown 5</a></li>
                </ul>
              </li>
              <li><a href="#">Dropdown 2</a></li>
              <li><a href="#">Dropdown 3</a></li>
              <li><a href="#">Dropdown 4</a></li>
            </ul>
          </li>
          <li><a href="#contact">Contact</a></li>
        </ul>
        <i class="mobile-nav-toggle d-xl-none bi bi-list"></i>
      </nav>

      <a class="cta-btn" href="#about">Get Started</a>

    </div>
  </header>

</template>

<script setup lang="ts">
import { onMounted, onUnmounted, ref } from 'vue';
const isScrolled = ref(false);
const handleScroll = () => {
  isScrolled.value = window.scrollY > 50
  console.log("oi: " + isScrolled.value);
}

onMounted(() => {
  window.addEventListener('scroll', handleScroll)
})

onUnmounted(() => {
  window.removeEventListener('scroll', handleScroll)
})
</script>

<style scoped></style>
