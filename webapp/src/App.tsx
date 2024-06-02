import { useState } from "react";
import { ToDoPage } from "./pages/ToDoPage";
import { login } from "./services/authService";

export const App = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(
    localStorage.getItem("accessToken") !== null
  );

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const loginUser = () => {
    login({ username, password })
      .then((tokenResponse) => {
        localStorage.setItem("accessToken", tokenResponse.accessToken);
        setIsLoggedIn(true);
      })
      .catch((error) => alert(error));
  };

  if (isLoggedIn) return <ToDoPage />;

  return (
    <div className="container py-5 h-100">
      <div>
        <input
          type="text"
          id="username-input"
          className="form-control"
          value={username}
          onChange={(event) => setUsername(event.target.value)}
        />
        <label className="form-label" htmlFor="username-input">
          username
        </label>

        <input
          type="password"
          id="password-input"
          className="form-control"
          value={password}
          onChange={(event) => setPassword(event.target.value)}
        />
        <label className="form-label" htmlFor="password-input">
          password
        </label>
      </div>
      <button onClick={loginUser}>Login</button>
    </div>
  );
};
