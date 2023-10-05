// cypress.config.js
module.exports = {
  baseUrl: "https://hw-traintimes.azurewebsites.net",
  e2e: {
    supportFile: "e2e.js", 
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
  component: {
    specPattern: "...", // Configuration for component tests, if needed
  }
};