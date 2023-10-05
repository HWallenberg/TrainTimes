// cypress.config.js
module.exports = {
  
  e2e: {
    baseUrl: "https://hw-traintimes.azurewebsites.net",
    supportFile: "e2e.js", 
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
  component: {
    specPattern: "...", // Configuration for component tests, if needed
  }
};