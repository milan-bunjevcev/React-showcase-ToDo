import { useState } from "react";
import { ToDoPage } from "./pages/ToDoPage";
import { login } from "./services/authService";
import { ACCESS_TOKEN_STORAGE_KEY } from "./Constants";

export const App = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(
    localStorage.getItem(ACCESS_TOKEN_STORAGE_KEY) !== null
  );

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const loginUser = async () => {
    try {
      const tokenResponse = await login({ username, password });
      localStorage.setItem(ACCESS_TOKEN_STORAGE_KEY, tokenResponse.accessToken);
      setIsLoggedIn(true);
    } catch (error) {
      alert(error);
    }
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
