// cypress.config.js
module.exports = {
  
  e2e: {
    baseUrl: "https://hw-traintimes.azurewebsites.net",
    "chromeWebSecurity": false,
    supportFile: "**/e2e/e2e.js", 
    specPattern: "e2e/*.cy.*",
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
  component: {
    specPattern: "...", // Configuration for component tests, if needed
  }
};