<template>
  <header>
    <div class="row g-0">
      <div class="p-2">
        <p class="fw-bold m-0">RiotBlossom</p>
      </div>
    </div>
  </header>

  <body>
    <div class="row g-0 justify-content-center">
      <aside class="col-12 col-lg-2">
        <div class="p-2 h-100">
          <div v-for="(value, key) in vm">
            <h5 class="fw-bold">{{ value.title }}</h5>
            <ul>
              <li v-for="(v2, k2) in value.items">
                  <NuxtLink :to="`/${key}/${k2}`" class="text-muted">
                    {{ v2.title }}
                  </NuxtLink>
              </li>
            </ul>
          </div>
        </div>
      </aside>

      <article class="col-12 col-lg-8">
        <div class="p-2 h-100">
          <slot></slot>
        </div>
      </article>

      <aside class="col-12 col-lg-2">
        <div class="p-2 h-100">
          <h4>In this article</h4>
        </div>
      </aside>
    </div>
  </body>

  <footer>
    <div class="row g-0">
      <div class="d-flex justify-content-around p-2">
        <p class="text-muted fw-bold">© 2023 Blossomi Shymae, made with love! 🏳️‍⚧️ 💜</p>
      </div>
    </div>
  </footer>
</template>

<script setup lang="ts">
import data from "./data.json";
const vm: any = data;
</script>
