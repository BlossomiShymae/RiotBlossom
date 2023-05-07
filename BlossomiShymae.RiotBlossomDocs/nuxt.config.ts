// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  app: {
    head: {
      link: [
        {
          rel: "stylesheet",
          href: "/css/bootstrap.css",
        },
        {
          rel: "stylesheet",
          href: "/css/main.css",
        },
      ],
      htmlAttrs: {
        "data-bs-theme": "dark",
      },
    },
  },
  modules: ["@nuxt/content"],
  content: {
    markdown: {
      anchorLinks: false,
    },
    highlight: {
      theme: "dracula",
    },
  },
});
