import "./Button.css";

function Button({ text, handleChange }) {
  return (
    <button className="myButton" onClick={handleChange}>
      {text}
    </button>
  );
}

export default Button;
