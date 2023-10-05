const { defineConfig } = require("cypress");

module.exports = defineConfig({
  e2e: {
    supportFile: "e2e.js", 
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
  component: {
    specPattern: "...", // Configuration for component tests, if needed
  },
  env: {
    BASE_URL: Cypress.env('BASE_URL')
  }
});
