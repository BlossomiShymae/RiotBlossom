import path from "path";

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  nitro: {
    output: {
      publicDir: path.join(__dirname, "..", "docs"),
    },
  },
  extends: "@nuxt-themes/docus",
  css: ["@fontsource/roboto", "@fontsource/cascadia-code", `@/assets/main.css`],
  app: {
    baseURL: "/RiotBlossom/",
    head: {
      link: [{ rel: "icon", type: "image/png", href: "/favicon.png" }],
    },
  },
  experimental: {
    payloadExtraction: false,
  },
});
