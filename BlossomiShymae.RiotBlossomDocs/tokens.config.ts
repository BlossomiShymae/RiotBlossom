import { defineTheme } from 'pinceau';

export default defineTheme({
  elements: {
    backdrop: {
      background: {
        dark: '#000804cc',
        initial: '#f4ecf7cc'
      }
    },
  },
  color: {
    primary: {
      50: "#f4ecf7",
      100: "#e8daef",
      200: "#d2b4de",
      300: "#bb8fce",
      400: "#a569bd",
      500: "#8e44ad ",
      600: "#7d3c98",
      700: "#6c3483",
      800: "#5b2c6f",
      900: "#4a235a"
    },
    secondary: {
      100: 'f6f3f3',
      900: '#102820'
    },
    black: "#000804",
    white: "#ffffff",
  },
  font: {
    sans: 'Roboto, sans-serif',
    mono: '"Cascadia Code", monospace',
  },
})
