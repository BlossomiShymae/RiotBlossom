// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  extends: '@nuxt-themes/docus',
  css: [
    '@fontsource/roboto',
    '@fontsource/cascadia-code',
    `@/assets/main.css`
  ],
  app: {
    head: {
        link: [{ rel: 'icon', type: 'image/png', href: '/favicon.png' }]
    }
},
});
