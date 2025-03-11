// import React, { createContext, useState, useContext, useEffect } from "react";
// import { useAuth } from "../contexts/AuthContext"; // Import your auth context to check if user is logged in
// import jazzMusik from "../Assets/Audio/JazzMusic"; // Your music file path

// const MusikContext = createContext();

// export default fuction JazzMusik() {
//   const { auth } = useAuth(); // Assuming this tells you if the user is logged in
//   const [musik, setMusik] = useState(null); // To store the current audio track
//   const [audio, setAudio] = useState(null);

//   const jazzMusik = new Audio(jazzMusik);

//   useEffect(() => {
//     let newAudio = null;

//     if (auth.isAuthenticated) {
//       newAudio = new Audio(jazzTrack);
//       newAudio.loop = true; // Keep playing the track in a loop
//       newAudio.play();
//       setAudio(newAudio);
//       setIsPlaying(true);
//     } 
//   }
//   )
//   }

