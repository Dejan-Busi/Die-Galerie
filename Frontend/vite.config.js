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
    open: true,
  },

  // Production
  preview: {
    watch: {
      usePolling: true,
    },
    host: true,
    strictPort: true,
    port: 4173,
    open: true,
  },
});
