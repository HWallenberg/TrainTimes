const { defineConfig } = require("cypress");

module.exports = defineConfig({

  supportFile: "e2e.js",
  
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
});
