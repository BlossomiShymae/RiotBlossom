// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  extends: '@nuxt-themes/docus',
  css: [
    '@fontsource/oxygen',
    '@fontsource/comic-mono',
    `@/assets/main.css`
  ],
  app: {
    head: {
        link: [{ rel: 'icon', type: 'image/png', href: '/favicon.png' }]
    }
},
});
