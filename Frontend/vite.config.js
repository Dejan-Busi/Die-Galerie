import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],

  // Development
  server: {
    watch: {
      usePolling: true,
    },
    host: true,
    strictPort: true,
    port: 5173,
  },

  // Production
  preview: {
    watch: {
      usePolling: true,
    },
    host: true,
    strictPort: true,
    port: 4173,
  },

  
  // Das "build"-Profil musst du eigentlich im Docker-Container einsetzen, 
  // wenn du deine Applikation hochschalten möchtest ↓

  // build: {
  //   rollupOptions: {
  //     // https://rollupjs.org/configuration-options/
  //   },
  // },
});

