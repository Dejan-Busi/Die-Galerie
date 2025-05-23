import React from "react";
import loading from "../Assets/Bilder/favicon.png";

function LoadingScreen() {
  return (
    <>
      <h1 id="ladeBildschirm">
        Laden...
        <img id="ladeSymbol" src={loading} alt="" />
      </h1>
    </>
  );
}

export default LoadingScreen;
