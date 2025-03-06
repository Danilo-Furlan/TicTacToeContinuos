///-----------------------------------------------------------------
///   Class:          TileController
///   Description:    Updates information relative to this tile
///   Author:         VueCode
///   GitHub:         https://github.com/ivuecode/
///-----------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    [Header("Component References")]
    public GameStateController gameController;                       // Reference to the gamecontroller
    public Button interactiveButton;                                 // Reference to this button
    public Text internalText;                                        // Reference to this Text



    /// <summary>
    /// Called everytime we press the button, we update the state of this tile.
    /// The internal tracking for whos position (the text component) and disable the button
    /// </summary>
    public void UpdateTile()
    {
        internalText.text = gameController.GetPlayersTurn();
        interactiveButton.image.sprite = gameController.GetPlayerSprite();
        interactiveButton.interactable = false;
        gameController.EndTurn();
    }

    /// <summary>
    /// Resets the tile properties
    /// - text component
    /// - buttton image
    /// </summary>
    public void ResetTile()
    {
        internalText.text = "";
        interactiveButton.image.sprite = gameController.tileEmpty;
    }

    /// <summary>  
    /// Verifica se este tile deve ter sua marca removida com base nos turnos do jogador.  
    /// Se o jogador que colocou esta marca tiver realizado 4 turnos, o tile é limpo e fica disponível novamente.  
    /// </summary>
    public void CheckVisibility(string currentPlayerTurn)
    {
        // Only count turns for the player who placed this mark
        if (!string.IsNullOrEmpty(playerMark) && playerMark == currentPlayerTurn)
        {
            playerTurnCount++;
            
            // If 4 turns of the same player have passed, clear the tile completely
            if (playerTurnCount >= 4)
            {
                ResetTile();
            }
        }



    /// <summary>  
    /// Retorna a marca do jogador neste tile para verificação de vitória.   
    /// </summary>
        
    public string GetPlayerMark()
    {
        return playerMark;
    }    

    }





}
