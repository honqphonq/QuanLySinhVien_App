/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js}"],
  theme: {
    extend: {
      colors: {
        brand: {
          DEFAULT: '#EFEFEF',
          foreground: '#111518',
        },
        primary: {
          200: '#c0e6ec',
          500: '#00b2be',
          700: '#00a0ab',
        },
      }
    },
  },
  plugins: [],
}

