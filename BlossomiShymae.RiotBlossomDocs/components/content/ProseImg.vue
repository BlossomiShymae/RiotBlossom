<template>
  <div class="img-container">
    <img
      class="img-fluid rounded"
      :src="refinedSrc"
      :alt="alt"
      :width="width"
      :height="height"
    />
  </div>
</template>

<style>
.img-container {
  max-width: 800px;
}
</style>

<script setup lang="ts">
import { withBase } from "ufo";
import { useRuntimeConfig, computed } from "#imports";
const props = defineProps({
  src: {
    type: String,
    default: "",
  },
  alt: {
    type: String,
    default: "",
  },
  width: {
    type: [String, Number],
    default: undefined,
  },
  height: {
    type: [String, Number],
    default: undefined,
  },
});
const refinedSrc = computed(() => {
  if (props.src?.startsWith("/") && !props.src.startsWith("//")) {
    return withBase(props.src, useRuntimeConfig().app.baseURL);
  }
  return props.src;
});
</script>
